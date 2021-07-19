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

  completeTask(taskId: number) {
    console.log('completing task: ' + taskId);
    // TODO: need to update list on successful complete
    this.taskService.completeTask(taskId)
    .subscribe(() => console.log('Completed task: ' + taskId));;
  }

  deleteTask(taskId: number) {
    console.log('deleting task: ' + taskId);
    // TODO: need to update list on successful removal
    this.taskService.deleteTask(taskId)
    .subscribe(() => console.log('Deleted task: ' + taskId));
  }

}
