using System.Collections.Generic;
using Sidekick.Domain.Game.Items.Models;

namespace Sidekick.Domain.Game.Trade.Models
{
    public class TradeItem : Item
    {
        public string Id { get; set; }
        public TradePrice Price { get; set; }

        public string Image { get; set; }

        public List<LineContent> PropertyContents { get; set; }
        public List<LineContent> RequirementContents { get; set; }
    }
}
