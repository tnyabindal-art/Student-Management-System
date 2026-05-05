import { Component } from '@angular/core';
import { StudentListComponent } from './components/student-list/student-list';
import { AddStudent } from './components/add-student/add-student';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [ AddStudent,StudentListComponent],  
  templateUrl: './app.html'
})
export class AppComponent {}