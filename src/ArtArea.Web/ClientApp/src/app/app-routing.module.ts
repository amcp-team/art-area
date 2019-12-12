import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { LoginComponent } from "./login/login.component";
import { RegisterComponent } from "./register/register.component";
import { HomeComponent } from "./home/home.component";
import { UserComponent } from "./user/user.component";
import { ProjectComponent } from "./project/project.component";
import { BoardComponent } from "./board-page/board/board.component";
import { PinComponent } from "./pin-page/pin/pin.component";

const routes: Routes = [
  { path: "", component: HomeComponent, pathMatch: "full" },
  { path: "login", component: LoginComponent },
  { path: "register", component: RegisterComponent },
  { path: ":username/:project", component: ProjectComponent },
  { path: ":username", component: UserComponent },
  { path: ":username/:project/:board", component: BoardComponent },
  { path: ":username/:project/:board/pin/:pin", component: PinComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { onSameUrlNavigation: "reload" })],
  exports: [RouterModule]
})
export class AppRoutingModule {}
