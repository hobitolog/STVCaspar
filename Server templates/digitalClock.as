package	{
	import flash.display.MovieClip;
	import flash.utils.Timer;
	import flash.events.TimerEvent;
	import se.svt.caspar.template.CasparTemplate;
	
	public class digitalClock extends CasparTemplate	{
		
		var aktualnaData:Date = new Date();
		
		var godziny:* = aktualnaData.hours;
		var minuty:* = aktualnaData.minutes;
		
		var licznik:Timer = new Timer(1000);
		
		public function digitalClock(){
			
			updateClock();
			
			licznik.addEventListener(TimerEvent.TIMER, updateTime)
			licznik.start()
		}
		
		private function updateClock(){
			
			if(String(minuty).length < 2){
							  minuty = "0" + minuty;
			}
			if(String(godziny).length < 2){
							  godziny = "0" + godziny;
			}
			
			clockText.text = godziny + ":" + minuty;
			
		}
		
		private function updateTime(e:TimerEvent){
			
			aktualnaData = new Date()
			
			godziny = aktualnaData.hours;
			minuty = aktualnaData.minutes;
			
			updateClock();
			
		}
		
		
	}
}