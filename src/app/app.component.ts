import { Component } from '@angular/core';
import {AppService} from './app.service';  
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Clientes';

  constructor(private AppService: AppService) { }  
  data: any;  
  Form: FormGroup;  
  submitted = false;   
  EventValue: any = "Save";  
  
  ngOnInit(): void {  
    this.getdata();  
  
    // this.Form = new FormGroup({  
    //   id: new FormControl("id"),  
    //   nome: new FormControl("nome"), 
    //   sobrenome: new FormControl("sobrenome"),        
    // })    
  }  
  getdata() {  
    this.AppService.getData().subscribe((data: any[]) => {  
      this.data = data;   
    })  
  }  
  // deleteData(id) {  
  //   this.AppService.deleteData(id).subscribe((data: any[]) => {  
  //     this.data = data;  
  //     this.getdata();  
  //   })  
  // }  
  // Save() {   
  //   this.submitted = true;  
    
  //    if (this.Form.invalid) {  
  //           return;  
  //    }  
  //   this.AppService.postData(this.Form.value).subscribe((data: any[]) => {  
  //     this.data = data;  
  //     this.resetFrom();  
  
  //   })  
  // }  
  // Update() {   
  //   this.submitted = true;  
    
  //   if (this.Form.invalid) {  
  //    return;  
  //   }        
  //   this.AppService.putData(this.Form.value.PagamentoId,this.Form.value).subscribe((data: any[]) => {  
  //     this.data = data;  
  //     this.resetFrom();  
  //   })  
  // }  
  
  // EditData(Data) {  
  //   this.Form.controls["id"].setValue(Data.id);  
  //   this.Form.controls["nome"].setValue(Data.nome);      
  //   this.EventValue = "Atualiza";  
  // }  
  
  // resetFrom()  
  // {     
  //   this.getdata();  
  //   this.Form.reset();  
  //   this.EventValue = "Save";  
  //   this.submitted = false;   
  // } 
}
