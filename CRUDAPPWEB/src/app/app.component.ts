import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  activeTab: number = 0;
  title = 'CRUDAPPWEB';

  changeTab(tab: number): void {
    console.log(tab);
    this.activeTab = tab;
  }
}
