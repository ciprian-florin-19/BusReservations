import { Status } from './status';

export interface User {
  id: string;
  fullName: string;
  phoneNumber: string;
  email?: string;
}
