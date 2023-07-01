import { Server } from "socket.io";
import dotenv from 'dotenv';
import ForceNick from "./Middlewares/forcenick.middleware";
import { Room } from "../types/room.type";
import MainController from './Controllers/main.controller'
import Http from 'http';
import express from 'express';
dotenv.config({path: "./.env"});


class Core extends MainController {
    private rooms: Room[] = [{
        uuid: 1,
        connects: []
    }]
    private port: number = Number(process.env.PORT);
    private kernel: Server;

    constructor() {
        super();
        const app = express();
        const httpServer = Http.createServer(app);
        this.kernel = new Server(httpServer, {
            cors: {
                origin: true
            }
        })
        this.loadMiddlewares();
        this.load(this.kernel, this.rooms);
        httpServer.listen(Number(process.env.PORT), ()=> {
            console.log("Servidor rodando...")
        })
    }

    private loadMiddlewares() {
        this.kernel.use(ForceNick);
    }

    
}

export default Core