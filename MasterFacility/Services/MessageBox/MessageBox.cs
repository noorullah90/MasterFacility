using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Westwind.Globalization;

public class MessageBox
{
    public static JsonResult Custom(string title,
                                  string message,
                                  MessageType type = MessageType.Success,
                                  MessageAlignment alignment = MessageAlignment.Center
                                  )
    {
        return new JsonResult(new
        {
            title = title,
            text = message,
            type = type.ToString().ToLower(),
            alignment = alignment.ToString().ToLower()
        });
    }

    public static JsonResult Show(MessageType type, MessageAlignment alignment=MessageAlignment.Center )
    {
        return new JsonResult(new
        {
            message = DbRes.T(type.ToString()== "NotValid"?"Error":type.ToString(), "MessageBox"),
            type = type.ToString().ToLower(),
            alignment = alignment.ToString().ToLower()
        });
        
    }
}

public enum MessageType
{
    Success,
    Error,
    Information,
    Warning,
    Alert,
    Notification,
    NotValid
}

public enum MessageAlignment
{
    Bottom,
    BottomCenter,
    BottomLeft,
    BottomRight,
    Center,
    CenterLeft,
    CenterRight,
    Inline,
    Top,
    TopCenter,
    TopLeft,
    TopRight,
}