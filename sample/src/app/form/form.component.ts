import { Component } from '@angular/core';
import { ServiceService } from '../service/service.service';
import { Employee } from '../models/employee';
import { ReactiveFormsModule } from '@angular/forms';
import { empty } from 'rxjs';
import { Company } from '../models/company';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent {

  Employee: Employee ={
      empName: "",
      empJoin:"",
      empAddress: "",
      empGender: "",
      empMobile: 0,
      empMail: ""
    }

    company:Company={
      name:"",
      role:"",
      fromDate:"",
      toDate:"",
      experiences:0,
      country:"",
      state:"",
      city:""
    }

  constructor(public Service: ServiceService) {
    //Testing
    console.log(Service.hi());

    // employee add to server 
    // console.log(Service.empAdd());
  }

  rows: any[] = [];

  add() {
    console.log(this.Employee);
    this.rows.push({
    });
    
  }

 

// save the company details 
save(){
  // this.Service.getcompany().subscribe((data)=>{
  //   console.log(data);
  // })
  this.Service.empAdd(this.Employee).subscribe((data)=>{
    console.log(data);
    })
  this.Service.addcompany(this.company).subscribe((data)=>{
    console.log(data);
  })
}

   edit(i:number){
    this.Service.editcompany(i+1,this.company).subscribe((data)=>{
      console.log(data);
    })
   }


  del(i: number) {
    this.rows.splice(i, 1);
    this.Service.removecompany(i+1).subscribe((data)=>{
      console.log(data);
    })
  }

}
