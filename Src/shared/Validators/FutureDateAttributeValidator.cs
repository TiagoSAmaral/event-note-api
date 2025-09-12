/*
* FutureDateAttributeValidator.cs 
* event-list 
*
* Created by Tiago Amaral on 06/09/2025. 
* Copyright ©2024 Tiago Amaral. All rights reserved.
*/

using System;
using System.ComponentModel.DataAnnotations;

namespace event_list.shared.dtos;

public class FutureDateAttributeValidator : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is not DateTime date)
            return false;

        return date > DateTime.UtcNow;
    }
}