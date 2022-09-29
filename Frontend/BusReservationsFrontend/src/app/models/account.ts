import { User } from './user';

export interface Account {
  username: string;
  password: string;
  user: User;
  hasAdminPrivileges: boolean;
}
