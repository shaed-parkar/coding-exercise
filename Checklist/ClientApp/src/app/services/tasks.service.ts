import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, throwError } from "rxjs";
import { catchError, tap } from "rxjs/operators";

@Injectable({
  providedIn: "root",
})
export class TasksService {
  private tasksUrl = "api/tasks";

  constructor(private http: HttpClient) {}

  allTasks$ = this.http.get<Task[]>(this.tasksUrl).pipe(
    tap((data) => console.log("Tasks", JSON.stringify(data))),
    catchError(this.handleError)
  );

  deleteTask(taskId: number) {
    return this.http.delete(`${this.tasksUrl}/${taskId}`);
  }

  completeTask(taskId: number) {
    return this.http.post(`${this.tasksUrl}/${taskId}/complete`, null);
  }

  addNewTask(description: string) {
    const body = {description};
    return this.http.post<Task>(this.tasksUrl, body).pipe(
      catchError(this.handleError)
    );
  }

  private handleError(err: any): Observable<never> {
    let errorMessage: string;
    if (err.error instanceof ErrorEvent) {
      errorMessage = `An error occurred: ${err.error.message}`;
    } else {
      errorMessage = `Backend returned code ${err.status}: ${err.body.error}`;
    }
    console.error(err);
    return throwError(errorMessage);
  }
}

export interface Task {
  id: number;
  description: string;
  completed: string;
}
