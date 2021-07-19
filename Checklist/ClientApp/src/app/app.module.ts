import { HttpClientModule } from "@angular/common/http";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { BrowserModule } from "@angular/platform-browser";
import { RouterModule } from "@angular/router";
import { AppComponent } from "./app.component";
import { HomeComponent } from "./home/home.component";
import { NavMenuComponent } from "./nav-menu/nav-menu.component";
import { TasksComponent } from "./tasks/tasks.component";

@NgModule({
  declarations: [AppComponent, NavMenuComponent, HomeComponent, TasksComponent],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: "", component: TasksComponent, pathMatch: "full" },
      { path: "tasks", component: TasksComponent },
    ]),
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
