// require ws module
const WebSocket = require('ws');
const wss = new WebSocket.Server({port: 8080}, ()=>{
    console.log('server started');
})

//this server we can listen to five event: close, connection, error, headers, listening
//client has 8 events we can listen to: close, error, message, open, ping, pong, unexpected-response, upgrade

wss.on('connection', (ws)=>{
    ws.on('message', (data)=>{
        console.log('data received: ' + data);
        ws.send(data);
    })
})

// print out msg once we're listening
wss.on('listening', ()=>{
    console.log('server is listening to port: 8080');
})