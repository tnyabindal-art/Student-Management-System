import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StudentService } from '../../services/student';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-student-list',
  standalone: true,
   imports: [CommonModule,FormsModule],
  templateUrl: './student-list.html'
})
export class StudentListComponent implements OnInit {

  students: any[] = [];
   selectedStudent: any = null;

  constructor(private studentService: StudentService) {}

  ngOnInit(): void {
    this.studentService.getStudents().subscribe((data: any) => {
      this.students = data;
    });
  }

  editstudent(student:any){
    this.selectedStudent={...student};
  }

  updatestudent(){
    this.studentService.updatestudent(this.selectedStudent.id,this.selectedStudent)
     .subscribe(()=>{alert('student updated successfully');
      this.ngOnInit();//refresh list
      this.selectedStudent=null;
     });
    
    }
    deleteStudent(id: string) {
  if (confirm('Are you sure to delete?')) {
    this.studentService.deleteStudent(id).subscribe(() => {
      alert('Student Deleted Successfully');
      this.ngOnInit();
    });
  }
}
  }

    
  
