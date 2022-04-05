// tslint:disable-next-line:class-name
export class authModelModel {
  id!: string;
  email!: string;
  expiresOn!: string;
  isAuthenticated = false;
  message!: string;
  roles: [] = [];
  token!: string;
  username!: string;
}
