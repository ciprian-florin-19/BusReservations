import { Status } from './Status';

export interface IUser {
  id: string;
  name: string;
  phoneNumber: string;
  email: string;
  status: Status;
}
