import { Injectable } from '@angular/core';
import { UserManager, User, MetadataService} from "oidc-client";

@Injectable()
export class LoginService {
    private mgr: UserManager;
    private user: User;

    constructor() {
        this.mgr = new UserManager(config);
    }
    
    login(): Promise<User> {
        return new Promise((resolve, reject) => {

            if (this.user) {
                resolve(this.user);
                return;
            }

            this.mgr.getUser().then(user => {
                if (user) {
                    this.user = user;
                    resolve(user);
                }
                else {
                    reject("not logged in");
                    this.mgr.signinRedirect();
                }
            });
        });

    }
}


const config : any = {
    authority: "http://localhost:5000",
    client_id: "js",
    redirect_uri: "http://localhost:5002/callback.html",
    response_type: "id_token token",
    scope: "openid profile api1",
    post_logout_redirect_uri: "http://localhost:5002/index.html",
};
