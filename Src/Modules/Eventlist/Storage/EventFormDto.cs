/*
* EventFormDto.cs 
* event-list 
*
* Created by Tiago Amaral on 06/09/2025. 
* Copyright ©2024 Tiago Amaral. All rights reserved.
*/

using System;
using System.ComponentModel.DataAnnotations;
using event_list.shared.exceptionsMessage;
using event_list.shared.dtos;

namespace event_list.modules.eventlist.storage;

public class EventFormDto
{
    [Key]
    public Guid? Id { get; set; } = null;
    
    [Required(ErrorMessage = ExceptionsMessages.InvalidTitleMessage)]
    [StringLength(ExceptionsContraints.MaxSizeTitle, ErrorMessage = ExceptionsMessages.MaxTitleSizeMessage)]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = ExceptionsMessages.InvalidDescriptionMessage)]
    [StringLength(ExceptionsContraints.MaxSizeDescription, ErrorMessage = ExceptionsMessages.MaxDescriptionSizeMessage)]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = ExceptionsMessages.InvalidDateMessage)]
    [FutureDateAttribute(ErrorMessage = ExceptionsMessages.InvalidFutureDateMessage)]
    public DateTime Date { get; set; }

    [Required(ErrorMessage = ExceptionsMessages.InvalidLocationMessage)]
    [StringLength(ExceptionsContraints.MaxSizeLocation, ErrorMessage = ExceptionsMessages.MaxLocationSizeMessage)]

    public string Locale { get; set; } = string.Empty;
}