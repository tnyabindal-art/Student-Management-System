import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { email } from '@angular/forms/signals';
import { StudentService } from '../../services/student';

@Component({
  selector: 'app-add-student',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './add-student.html',
  styleUrl: './add-student.css',
})
export class AddStudent {
  student:any={
    name: '',
    email: '',
    phone: '',
    course:'',
  };

  constructor (private studentservice:StudentService){}

 onSubmit(){
   console.log("Form Submit Triggered"); 
    this.studentservice.addstudent(this.student).subscribe(()=>{alert('student added successfully');})
  }
  }

