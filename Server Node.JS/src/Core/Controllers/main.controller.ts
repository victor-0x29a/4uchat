import {Server, Socket} from 'socket.io';
import { Room } from '../../types/room.type';
import ChatModule from '../modules/chat.module'
import { User } from '../../types/user.type';

class MainController {

    private OnConnect(socket: Socket, rooms: Room[], kernel: Server) {
        const indexInRoom = rooms[0].connects.findIndex(User => User.socket.id === socket.id)
        kernel.to(rooms[0].uuid.toString()).emit("UsersConnecteds", (rooms[0].connects.length).toString());
        kernel.to(rooms[0].uuid.toString()).emit("UserConnected", rooms[0].connects[indexInRoom].name + "#" + socket.id.slice(0, 3));
    }

    public load(kernel: Server, rooms: Room[]) {
        kernel.on("connection", (socket: Socket)=> {
            socket.join("1")

            rooms[0].connects.push({
                name: socket.handshake.query["name"].toString(),
                socket: socket
            })


            this.OnConnect(socket, rooms, kernel);
            

            socket.on("Typing", () => {
                const User: User = rooms[0].connects.find((User)=> User.socket.id === socket.id && User);
                kernel.to(rooms[0].uuid.toString()).emit("UserTyping", User.name, socket.id);
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
                kernel.to(rooms[0].uuid.toString()).emit("UserDisconnected", rooms[0].connects[indexInRoom].name + "#" + socket.id.slice(0, 3));
                rooms[0].connects.splice(indexInRoom, 1);
                kernel.to(rooms[0].uuid.toString()).emit("UsersConnecteds", (rooms[0].connects.length).toString());
            })


        })
    }

    private chat() {

    }
}

export default MainController;