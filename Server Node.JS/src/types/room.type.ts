import { User } from "./user.type";

export interface Room {
    uuid: number;
    connects: User[];
}