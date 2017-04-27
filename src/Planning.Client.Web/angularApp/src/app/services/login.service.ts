import { Injectable } from '@angular/core';
import { UserManager, User, MetadataService, OidcClient } from "oidc-client";

@Injectable()
export class LoginService {
  private mgr: UserManager;
  private client: OidcClient;
  private user: User;

  constructor() {
    this.mgr = new UserManager(config);
    this.client = new OidcClient(config);
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
            this.client.createSigninRequest().then(function (req) {
              console.log("signin request", req, "<a href='" + req.url + "'>go signin</a>");
              window.location.href = req.url;
            }).catch(err => {
              reject(err);
            });
        }
      });
    });
  }

  logout() {
    //alert("loginservice.logout");
    //this.mgr.signoutRedirectCallback().then(this.login);
    //this.mgr.signoutPopup().then(this.login);
    //return this.mgr.removeUser().then(this.login);
    this.client.createSignoutRequest().then(req => {
      this.mgr.removeUser().then(() => {
        window.location.href = req.url;
      });
    });
  }
}


const config: any = {
  authority: "http://localhost:5000",
  client_id: "js",
  redirect_uri: "http://localhost:5002/callback.html",
  response_type: "id_token token",
  scope: "openid profile api1",
  post_logout_redirect_uri: "http://localhost:5002/index.html",
};
