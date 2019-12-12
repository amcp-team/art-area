import { BrowserModule } from "@angular/platform-browser";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations"
import { NgModule } from "@angular/core";
import { HttpClientModule } from "@angular/common/http";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { CommonModule } from "@angular/common";

import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { LoginComponent } from "./login/login.component";
import { RegisterComponent } from "./register/register.component";
import { jwtInterceptorProvider } from "./app-auth/jwt.interceptor";
import { errorInterceptorProvider } from "./app-auth/error.interceptor";
import { HomeComponent } from "./home/home.component";
import { UserComponent } from "./user/user.component";
import { NavComponent } from "./nav/nav.component";
import { NavUserBadgeComponent } from "./nav-user-badge/nav-user-badge.component";
import { UserDataComponent } from "./user-data/user-data.component";
import { UserProjectsComponent } from "./user-projects/user-projects.component";
import { ProjectComponent } from "./project/project.component";
import { ProjectDataComponent } from "./project-data/project-data.component";
import { UserCreateProjectComponent } from "./user-create-project/user-create-project.component";
import { ProjectBoardsComponent } from "./project-boards/project-boards.component";
import { BoardComponent } from "./board-page/board/board.component";
import { BoardDataComponent } from "./board-page/board-data/board-data.component";
import { BoardPinsComponent } from "./board-page/board-pins/board-pins.component";
import { ProjectCreateBoardComponent } from "./project-create-board/project-create-board.component";
import { PinImgComponent } from "./pin-page/pin-img/pin-img.component";
import { PinCommentsListComponent } from "./pin-page/pin-comments-list/pin-comments-list.component";
import { PinCreatingCommentComponent } from "./pin-page/pin-creating-comment/pin-creating-comment.component";
import { PinHeadComponent } from "./pin-page/pin-head/pin-head.component";
import { PinComponent } from "./pin-page/pin/pin.component";
import { BoardCreatePinComponent } from './board-page/board-create-pin/board-create-pin.component';
// import { AnimationComponent } from './animation/animation.component';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    HomeComponent,
    UserComponent,
    NavComponent,
    NavUserBadgeComponent,
    UserDataComponent,
    UserProjectsComponent,
    ProjectComponent,
    ProjectDataComponent,
    UserCreateProjectComponent,
    ProjectBoardsComponent,
    BoardComponent,
    BoardDataComponent,
    BoardPinsComponent,
    ProjectCreateBoardComponent,
    PinImgComponent,
    PinCommentsListComponent,
    PinCreatingCommentComponent,
    PinHeadComponent,
    PinComponent,
    BoardCreatePinComponent,
    // AnimationComponent,
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    CommonModule
  ],
  exports: [
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    CommonModule
  ],
  providers: [jwtInterceptorProvider, errorInterceptorProvider],
  bootstrap: [AppComponent]
})
export class AppModule {}
