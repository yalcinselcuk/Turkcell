/*
 * Dependency : bagimlilik, bir nesnenin varliginin baska bir nesneye bagli olmasi durumu
 * 
 * matkap ucu olmadan calismaz
 * pil olmadan mouse calismaz
 * ram olmadan pc calismaz
 * 
 * 
 * Inversion : buyuk sistem, bagimlisi oldugu nesneyi olusturmamali. Disaridan almali
 * 
 */

using DependencyInversion;

Reporter reporter= new Reporter(new MailSender());
reporter.SendReport();

Reporter reporter2 = new Reporter(new WhatsappSender());
reporter2.SendReport();

Reporter reporter3 = new Reporter(new TelegramSender());
reporter3.SendReport();