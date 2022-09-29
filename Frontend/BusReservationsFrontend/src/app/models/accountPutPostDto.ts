import { UserPutPostDto } from './userPutPostDto';

export interface AccountPutPostDto {
  username: string;
  password: string;
  user: UserPutPostDto;
}
