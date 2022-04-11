import {authModelModel} from '../models/authModel.model';

export class LocalStoragemangerModel{
   putAccounntInLocal(data:any){
     const authMd = new authModelModel();
     authMd.id = data.userId;
     authMd.email = data.email;
     authMd.pathImage = data.pathImage;
     authMd.expiresOn = data.expiresOn;
     authMd.isAuthenticated = data.isAuthenticated;
     authMd.message = data.message;
     authMd.token = data.token;
     authMd.username = data.username;
     authMd.roles = data.roles;
     localStorage.setItem('autMd', JSON.stringify(authMd));
   }
}
