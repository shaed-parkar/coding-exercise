import { Component } from "@angular/core";
import {
  AbstractControl,
  FormBuilder,
  FormGroup,
  Validators,
} from "@angular/forms";
import { TasksService } from "../services/tasks.service";

@Component({
  selector: "app-create-task",
  templateUrl: "./create-task.component.html",
  styleUrls: ["./create-task.component.css"],
})
export class CreateTaskComponent {
  form: FormGroup;

  constructor(private taskService: TasksService, private fb: FormBuilder) {
    this.form = this.fb.group({
      description: ["", Validators.required],
    });
  }

  get taskDescription(): AbstractControl {
    return this.form.get("description");
  }

  addNewTask() {
    if (this.form.valid) {
      console.log("adding a new task");
      // TODO: need to update list on successful add
      this.taskService
        .addNewTask(this.taskDescription.value)
        .subscribe((task) => {
          console.log(task);
        });
    } else {
      console.warn("form is not valid yet");
      console.log(this.form.errors);
    }
  }
}
