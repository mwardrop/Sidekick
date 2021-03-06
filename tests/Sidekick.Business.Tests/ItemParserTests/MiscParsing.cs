using FluentAssertions;
using NUnit.Framework;
using Sidekick.Business.Apis.Poe.Models;
using Sidekick.Business.Apis.Poe.Parser;
using Sidekick.Business.Apis.Poe.Trade.Data.Items;

namespace Sidekick.Business.Tests.ItemParserTests
{
    public class MiscParsing : TestContext<ParserService>
    {
        [Test]
        public void ParseProphecy()
        {
            var actual = Subject.ParseItem(Prophecy);

            actual.Rarity.Should().Be(Rarity.Prophecy);
            actual.Name.Should().Be("The Four Feral Exiles");
        }

        [Test]
        public void ParseDivinationCard()
        {
            var actual = Subject.ParseItem(DivinationCard);

            actual.Rarity.Should().Be(Rarity.DivinationCard);
            actual.Type.Should().Be("The Saint's Treasure");
        }

        [Test]
        public void ParseShaperItemDivinationCard()
        {
            var actual = Subject.ParseItem(ShaperItemDivinationCard);

            actual.Rarity.Should().Be(Rarity.DivinationCard);
            actual.Type.Should().Be("The Lord of Celebration");
            actual.Influences.Shaper.Should().BeFalse();
        }

        [Test]
        public void ParseCurrency()
        {
            var actual = Subject.ParseItem(Currency);

            actual.Rarity.Should().Be(Rarity.Currency);
            actual.Type.Should().Be("Divine Orb");
        }

        [Test]
        public void ParseOrgan()
        {
            var actual = Subject.ParseItem(Organ);

            actual.Rarity.Should().Be(Rarity.Unique);
            actual.Category.Should().Be(Category.ItemisedMonster);
            actual.Type.Should().Be("Portentia, the Foul");
        }

        #region ItemText

        private const string Prophecy = @"Rarity: Normal
The Four Feral Exiles
--------
In a faraway dream, four souls far from home prepare to fight to the death.
--------
You will enter a map that holds four additional Rogue Exiles.
--------
Right-click to add this prophecy to your character.
";

        private const string DivinationCard = @"Rarity: Divination Card
The Saint's Treasure
--------
Stack Size: 1/10
--------
2x Exalted Orb
--------
Publicly, he lived a pious and chaste life of poverty. Privately, tithes and tributes made him and his lascivious company very comfortable indeed.
";

        private const string Currency = @"Rarity: Currency
Divine Orb
--------
Stack Size: 2/10
--------
Randomises the numeric values of the random modifiers on an item
--------
Right click this item then left click a magic, rare or unique item to apply it.
Shift click to unstack.
";

        private const string ShaperItemDivinationCard = @"Rarity: Divination Card
The Lord of Celebration
--------
Stack Size: 1/4
--------
Sceptre of Celebration
Shaper Item
--------
Though they were a pack of elite combatants, the Emperor's royal guards were not ready to face one of his notorious parties.";

        private const string Organ = @"Rarity: Unique
Portentia, the Foul's Heart
--------
Uses: Blood Bubble
--------
Item Level: 79
--------
Drops a Rare Weapon
Drops additional Rare Armour
Drops additional Rare Armour
Drops additional Rare Jewellery
--------
Combine this with four other different samples in Tane's Laboratory.";
        #endregion
    }
}
