import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {  
  title = 'Adm Boa Fé';
  clients: any;
  constructor (private http: HttpClient) {}

  ngOnInit(): void {
    this.http.get('http://localhost:5198/api/clients').subscribe({
      next: response => this.clients = response,
      error: error => console.log(error),
      complete: () => console.log("Request has completed"),
    })
  }

}
