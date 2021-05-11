import { Component, OnInit } from '@angular/core';
import { UsersService } from '../core/services/users.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  userActive: boolean = false;
  user: any;
  constructor(private userService: UsersService) {}

  ngOnInit() {
    this.userService.getUser().subscribe((user)=>{
        this.user = user;
        this.userActive = true;
    });
  }

}
