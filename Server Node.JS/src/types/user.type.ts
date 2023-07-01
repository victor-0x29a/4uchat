import {Socket} from 'socket.io';
export interface User {
    name: string;
    socket: Socket;
}