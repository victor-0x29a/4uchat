import {Socket, Server} from 'socket.io'
import { Room } from '../../types/room.type';
import { User } from '../../types/user.type';


function getUser(room: Room, socket: Socket) {
    return room.connects.find((User)=> User.socket.id === socket.id && User);
}

export default function ChatModule(socket: Socket, kernel: Server, room: Room, message: String, debug: boolean) {
    const ThisUser: User = getUser(room, socket);
    if(debug) {
        console.log(`
        Author: ${ThisUser.name}
        Mensagem: ${message}
        `);
    }
    kernel.to(room.uuid.toString()).emit("MessageReceiv", {
        Content: message,
        From: `${ThisUser.name}#${socket.id.slice(0, 3)}`
    })
}