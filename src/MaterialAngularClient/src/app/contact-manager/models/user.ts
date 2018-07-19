import { UserNote } from "./user-note";

export interface User {
  id: number;
  birthDate: Date;
  name: string;
  avatar: string;
  bio: string;

  userNotes: UserNote[];
}
