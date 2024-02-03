/*
// require ws module
const WebSocket = require('ws');
const wss = new WebSocket.Server({port: 3000}, ()=>{
    console.log('server started');
})

//this server we can listen to five event: close, connection, error, headers, listening
//client has 8 events we can listen to: close, error, message, open, ping, pong, unexpected-response, upgrade

wss.on('connection', (ws) => {
    ws.on('message', (data) => {
        
        //console.log('data received \n %o', data);
        //ws.send(data);
        
        // Convert Buffer to string
        const message = data.toString('utf8');
        console.log('data received \n', message);
        ws.send(message);
    });
});



// print out msg once we're listening
wss.on('listening', ()=>{
    console.log('server is listening to port: 3000');
})
*/
const WebSocket = require('ws');
const wss = new WebSocket.Server({ noServer: true });

wss.on('connection', (ws) => {
    ws.on('message', (data) => {
        //console.log('Received raw message:', data);
        // ws.send(data);

        // Convert Buffer to string
        const message = data.toString('utf8');
        console.log('data received \n', message);
        ws.send(message);
    });

    ws.on('close', () => {
        console.log('WebSocket closed');
    });
});

const server = require('http').createServer();

server.on('upgrade', (request, socket, head) => {
    wss.handleUpgrade(request, socket, head, (ws) => {
        wss.emit('connection', ws, request);
    });
});

server.listen(3000, () => {
    console.log('Server listening on port 3000');
});
