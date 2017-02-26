import { Injectable, Inject } from "@angular/core";
import { Todo } from "../models/todo";
import { LoginService } from "./login.service";
import { Headers, Http } from "@angular/http";

import 'rxjs/add/operator/toPromise';

@Injectable()
export class TodoService {

    constructor(private http: Http, private loginService: LoginService) {}

    loadTodos(): Promise<Todo[]> {
        return new Promise((resolve, reject) => {

            this.loginService.login().then(user => {
                
                const headers = new Headers({ 'Accept': 'application/json' });
                const bearer = `Bearer ${user.access_token}`;
                headers.append("Authorization", bearer);

                return this.http
                    .get("http://localhost:5001/api/values", { headers: headers })
                    .toPromise()
                    .then(response => {
                        var json = response.json();
                        resolve(json as Todo[]);
                    })
                    .catch(this.handleError);
            });
        });
    }

    addTodo(todo: Todo): Promise<any> {
        return this.http
            .post('api/values', todo)
            .toPromise()
            .catch(this.handleError);
    }

    deleteTodo(id: number) {
        return this.http
            .delete("api/values/" + id)
            .toPromise()
            .catch(this.handleError);
    }

    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error); // for demo purposes only
        return Promise.reject(error.message || error);
    }

}
