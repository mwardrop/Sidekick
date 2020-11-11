using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Sidekick.Domain.Game.Languages;
using Sidekick.Domain.Game.Languages.Commands;

namespace Sidekick.Application.Languages
{
    public class SetLanguageHandler : ICommandHandler<SetLanguageCommand>
    {
        private readonly ILanguageProvider languageProvider;
        private readonly ILogger<SetLanguageHandler> logger;

        public SetLanguageHandler(
            ILanguageProvider languageProvider,
            ILogger<SetLanguageHandler> logger)
        {
            this.languageProvider = languageProvider;
            this.logger = logger;
        }

        public Task<Unit> Handle(SetLanguageCommand request, CancellationToken cancellationToken)
        {
            var language = languageProvider.AvailableLanguages.Find(x => x.LanguageCode == request.LanguageCode);

            if (language == null)
            {
                logger.LogWarning("Couldn't find language matching {language}.", request.LanguageCode);
                return Unit.Task;
            }

            languageProvider.Language = (ILanguage)Activator.CreateInstance(language.ImplementationType);

            return Unit.Task;
        }
    }
}
