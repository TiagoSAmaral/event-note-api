/*
* EventModel.cs 
* event-list 
*
* Created by Tiago Amaral on 06/09/2025. 
* Copyright ©2024 Tiago Amaral. All rights reserved.
*/

namespace Module.Eventlist.Storage.Entity;
public class EventModel
{
    public int id { get; set; }
    public string title { get; set; }
    public DateTime data { get; set; }
    public string locale { get; set; }
}