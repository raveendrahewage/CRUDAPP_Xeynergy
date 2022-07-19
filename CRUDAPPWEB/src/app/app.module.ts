import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { AccessRuleComponent } from './access-rule/access-rule.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { Routes, RouterModule } from '@angular/router';
import { UserGroupComponent } from './user-group/user-group.component';
import { UserComponent } from './user/user.component';
import { AccessRuleService } from './services/access-rule/access-rule.service';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { WelcomePageComponent } from './welcome-page/welcome-page.component';

const routes: Routes = [
  { path: '', component: WelcomePageComponent },
  { path: 'access-rule', component: AccessRuleComponent },
  { path: 'user-group', component: UserGroupComponent },
  { path: 'user', component: UserComponent },
];
@NgModule({
  declarations: [
    AppComponent,
    AccessRuleComponent,
    UserGroupComponent,
    UserComponent,
    WelcomePageComponent,
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(routes),
    BrowserAnimationsModule,
    HttpClientModule,
    ReactiveFormsModule,
  ],
  exports: [RouterModule],
  providers: [AccessRuleService],
  bootstrap: [AppComponent],
})
export class AppModule {}
