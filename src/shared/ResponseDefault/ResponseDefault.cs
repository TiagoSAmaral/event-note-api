/*
* ResponseDefault.cs 
* event-list 
*
* Created by Tiago Amaral on 06/09/2025. 
* Copyright ©2024 Tiago Amaral. All rights reserved.
*/

namespace event_list.shared.response_default;

public class ResponseDefault
{
    public int Status { get; set; }
    public string Message { get; set; } = string.Empty;
    public object? Data { get; set; }

    public ResponseDefault(int status, string message, object? data)
    {
        this.Status = status;
        this.Message = message;
        this.Data = data;
    }
}