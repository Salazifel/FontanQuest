using System;
using System.Collections.Generic;
using System.Text;

namespace syp.biz.SockJS.NET.Client
{
    public enum StompCommandEnum
    {
        CONNECT,
        CONNECTED,
        SEND,
        SUBSCRIBE,
        UNSUBSCRIBE,
        ACK,
        NACK,
        BEGIN,
        COMMIT,
        ABORT,
        DISCONNECT,
        MESSAGE,
        RECEIPT,
        ERROR
    }
}
