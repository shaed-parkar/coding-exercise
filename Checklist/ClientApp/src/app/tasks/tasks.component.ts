import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Task, TasksService } from '../services/tasks.service';

@Component({
  selector: 'app-tasks',
  templateUrl: './tasks.component.html',
  styleUrls: ['./tasks.component.css']
})
export class TasksComponent implements OnInit {
  allTasks$: Observable<Task[]>;

  constructor(private taskService: TasksService) { }

  ngOnInit() {
    this.allTasks$ = this.taskService.allTasks$;
  }

  addNewTask(description: string) {
    this.taskService.addNewTask(description)
  }

  completeTask(taskId: number) {
    this.taskService.completeTask(taskId);
  }

  deleteTask(taskId: number) {
    this.taskService.deleteTask(taskId)
  }

}
