import {Socket} from 'socket.io';

export default function ForceNick(socket: Socket, next: () => any) {
    try {
        const UserName: string | undefined = socket.handshake.query["name"].toString();
        if(!UserName || UserName.length > 25) {
            socket.disconnect(true);
        } else {
            next();
        }
    } catch(e: any) {
        socket.disconnect(true);
    }
}