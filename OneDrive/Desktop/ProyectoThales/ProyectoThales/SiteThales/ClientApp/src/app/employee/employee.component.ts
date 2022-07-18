import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';


@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent {
  public information: Data;
  public informationList: Data[];

  constructor(private http: HttpClient) {

  }

  public Search(id: number): void {
    console.log("vacio:" + id);
    if (String(id) != "") {
      this.http.get<Data>('https://localhost:44349/' + 'SearchEmployeeId?Id=' + id).subscribe(result => {
        this.information = result;
        console.log(this.information);
      }, error => console.error(error));
    }
    else {
      this.SearchAll();
    }
  }

  public SearchAll(): void {
    console.log('https://localhost:44349/' + 'SearchEmployees');
    this.http.get<Data[]>('https://localhost:44349/' + 'SearchEmployees').subscribe(result => {
      this.informationList = result;
      console.log(this.informationList);
    }, error => console.error(error));
  }

}

interface Data {
  id: number;
  employeeName: string;
  employeeSalary: number;
  employee_anual_Salary: number;
  employeeAge: number;
  profileImage: string;
}
