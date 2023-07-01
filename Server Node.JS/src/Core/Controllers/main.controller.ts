import {Server, Socket} from 'socket.io';
import { Room } from '../../types/room.type';
import ChatModule from '../modules/chat.module'

class MainController {

    public load(kernel: Server, rooms: Room[]) {
        kernel.on("connection", (socket: Socket)=> {
            console.log("+ 1")
            socket.join("1")

            
            kernel.to(rooms[0].uuid.toString()).emit("UsersConnecteds", (rooms[0].connects.length + 1).toString());

            rooms[0].connects.push({
                name: socket.handshake.query["name"].toString(),
                socket: socket
            })

            socket.on("ChangeNick", (NewNick: string)=> {
                if (NewNick.length > 25 || !NewNick) {
                    socket.emit("rejectNick");
                    return;
                } 
                const indexUser: number = rooms[0].connects.findIndex((User)=> User.socket.id === socket.id);
                rooms[0].connects[indexUser].name = NewNick;
                socket.emit("acceptedNick", rooms[0].connects[indexUser].name);
            })

            socket.on("Message", (ContentMessage: string)=> {
                const content = JSON.parse(ContentMessage);
                ChatModule(socket, kernel, rooms[0], content["Content"], true);
            })

            socket.on("disconnect", ()=> {
                const indexInRoom = rooms[0].connects.findIndex(User => User.socket.id === socket.id)
                rooms[0].connects.splice(indexInRoom, 1);
                kernel.to(rooms[0].uuid.toString()).emit("UsersConnecteds", (rooms[0].connects.length + 1).toString());
            })
        })
    }

    private chat() {

    }
}

export default MainController;