import { CommonModule } from "@angular/common";
import { NgModule, Optional, SkipSelf } from "@angular/core";
import { RouterModule } from "@angular/router";

@NgModule({
  imports: [CommonModule, RouterModule],
  exports: [
    // components that are used in app.component.ts will be listed here.
  ],
  declarations: [
    // components that are used in app.component.ts will be listed here.
  ],
  providers: [
    /* ``No`` global singleton services of the whole app should be listed here anymore!
       Since they'll be already provided in AppModule using the `tree-shakable providers` of Angular 6.x+ (providedIn: 'root').
       This new feature allows cleaning up the providers section from the CoreModule.
       But if you want to provide something with an InjectionToken other that its class, you still have to use this section.
    */
  ]
})
export class CoreModule {
  constructor(@Optional() @SkipSelf() core: CoreModule) {
    if (core) {
      throw new Error("CoreModule should be imported ONLY in AppModule.");
    }
  }
}
