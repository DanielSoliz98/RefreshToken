import { Injectable } from '@angular/core';
import { CanActivate, CanLoad, Route, UrlSegment, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class HomeGuard implements CanActivate, CanLoad {

  constructor(private authService: AuthService, private router: Router) { }
  canActivate(){
    return this.canLoad();
  }
  canLoad(){
    if (!this.authService.isLoggedIn()) {
      this.router.navigate(['/login']);
    }
    return this.authService.isLoggedIn();
  }
}
