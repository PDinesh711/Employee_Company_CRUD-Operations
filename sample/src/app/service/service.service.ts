import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Employee } from '../models/employee';
import { Company } from '../models/company';

@Injectable({
  providedIn: 'root'
})
export class ServiceService {

  constructor(private http: HttpClient) { }

  baseUrl: string = "https://localhost:7297/api"

  hi() {
    console.log("hi ! i am Service ");
  }

  // Employee 
  empAdd(Emp: Employee) {
    return this.http.post<any>(`${this.baseUrl}/Employee/save`, Emp)
  }

  // Company 
  getcompany() {
    return this.http.get(`${this.baseUrl}/Company/getAll`)
  }

  addcompany(i: Company) {
    return this.http.post<any>(`${this.baseUrl}/Company/save`, i, { responseType: 'json' })
  }

  removecompany(i: number) {
    return this.http.delete<any>(`${this.baseUrl}/Company/delete/${i}`)
  }

  editcompany(i:number,company:Company){
    return this.http.put<any>(`${this.baseUrl}/Company/update/${i}`,company,{responseType:'json'})
  }


}
