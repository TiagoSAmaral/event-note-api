/*
* ExceptionsMessager.cs 
* event-list 
*
* Created by Tiago Amaral on 06/09/2025. 
* Copyright ©2024 Tiago Amaral. All rights reserved.
*/


namespace event_list.shared.exceptionsMessage;

public sealed class ExceptionsMessages
{

    public const string InvalidTitleMessage = "Nome inválido";
    public const string MaxTitleSizeMessage = $"Titulo além do tamanho permitido";

    public const string InvalidDescriptionMessage = "Descrição inválida";
    public const string MaxDescriptionSizeMessage = $"Descrição além do tamanho permitido";

    public const string InvalidDateMessage = "Data do evento inválida";
    public const string InvalidFutureDateMessage = "Data deve ser maior que atual";

    public const string InvalidLocationMessage = "Local inválido";
    public const string MaxLocationSizeMessage = $"Local além do tamanho permitido";

    public const string SuccessCreateEvent = "Evento criado com sucesso";
    public const string SuccessDeleteEvent = "Evento apagado com sucesso";
}