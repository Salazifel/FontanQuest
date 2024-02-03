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
        const message = data.toString('utf8');
        
        // Implement Stomp protocol handling here
        handleStompMessage(ws, message);
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

function handleStompMessage(ws, message) {
    // Implement Stomp protocol handling
    // Parse Stomp message and handle accordingly
    // This depends on the specific requirements of Fitrockr's Stomp protocol
    // For simplicity, let's assume you need to handle CONNECT, SUBSCRIBE, and SEND frames

    if (message.includes('CONNECT')) {
        // Handle CONNECT frame
        ws.send('CONNECTED\nversion:1.2\n\n\0');
    } else if (message.includes('SUBSCRIBE')) {
        // Handle SUBSCRIBE frame
        ws.send('MESSAGE\ndestination:/topic/live\ncontent-type:application/json\n\n{"example": "data"}\0');
    } else if (message.includes('SEND')) {
        // Handle SEND frame
        // Extract and process the message data
        console.log(`Received Stomp message: ${message}`);
    }
}
