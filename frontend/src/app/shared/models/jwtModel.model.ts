export class JwtModel {
    id = "";
    username = "";
    email = "";
    pathImage = "";
    isAuthenticated = false;
    roles = new Array<string>();
    token = "";
    message = null;
    expiresOn = "";
}