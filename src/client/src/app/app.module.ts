import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { AuthService } from './services/auth.service';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthGuardService } from './services/auth-guard.service';
import { RegisterComponent } from './register/register.component';
import { PetFoodCategoryService } from './services/petFood-category.service';
import { FoodCategoryComponent } from './food-category/food-category.component';
import { NavbarComponent } from './shared/navbar/navbar.component';
import { FoodBrandComponent } from './food-brand/food-brand.component';
import { FoodComponent } from './food/food.component';
import { FoodDetailComponent } from './food-detail/food-detail.component';
import { CartComponent } from './cart/cart.component';
import { TokenInterceptorService } from './services/token-interceptor.service';
import { FoodResolver } from './services/resolvers/food.resolver';
import { HomeComponent } from './home/home.component';
import { ThankyouComponent } from './thankyou/thankyou.component';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { NotificationsService } from './services/notifications.service';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    FoodCategoryComponent,
    NavbarComponent,
    FoodBrandComponent,
    FoodComponent,
    FoodDetailComponent,
    CartComponent,
    HomeComponent,
    ThankyouComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
  ],
  providers: [
    AuthService,
    AuthGuardService,
    PetFoodCategoryService,
    NotificationsService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptorService,
      multi: true
    },
    FoodResolver
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
