import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  baseUrl = 'https://localhost:7168/api/student';

  constructor(private http: HttpClient) {}

  getStudents() {
    return this.http.get(this.baseUrl);
  }
  addstudent(student:any){
    return this.http.post(this.baseUrl,student);
    
  }

  updatestudent(id: string, student: any) {
  return this.http.put(`${this.baseUrl}/${id}`, student);
}

deleteStudent(id: string) {
  return this.http.delete(`${this.baseUrl}/${id}`);
}
}
