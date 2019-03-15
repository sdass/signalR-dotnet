<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebAppSignalR3.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>startpage</title>
        <style type="text/css">
        .container {
            background-color: #99CCFF;
            border: thick solid #808080;
            padding: 20px;
            margin: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p> start page</p>
    </div>
    </form>
        <div class="container">
        <input type="text" id="message" />
        <input type="button" id="sendmessage" value="Send" />
        <input type="hidden" id="displayname" />
        <ul id="discussion">
        </ul>
    </div>
    <script src="scripts/jquery-1.6.4.js"></script>
    <script src="scripts/jquery.signalR-2.4.0.js"></script>
    <script src="signalr/hubs"></script>

    <script type="text/javascript">
        $(function () {
            var hatproxy = $.connection.myHub;
            hatproxy.client.addMessage = function (name, message) {
                console.log(name + '----' + message);
                var encodedName = $('<div />').text(name).html();
                var encodedMsg = $('<div />').text(message).html();
                // Add the message to the page. 
                $('#discussion').append('<li><strong>' + encodedName + '</strong>:&nbsp;&nbsp;' + encodedMsg + '</li>');
            };

            $('#displayname').val(prompt('Enter your name:', ''));
            $('#message').focus();
            $.connection.hub.start().done(function () {
                $('#sendmessage').click(function () {
                    hatproxy.server.send($('#displayname').val(), $('#message').val());
                    $('#message').val('').focus();

                });
            });
        });
    </script>

</body>
</html>
