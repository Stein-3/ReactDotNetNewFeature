import { atom, useRecoilState } from "recoil";
import { WetherForecasts } from "./Interface";

const useFetchData = () => {
  const [wetherForecasts, setWetherForecasts] = useRecoilState(fetchDataState);

  fetch("https://localhost:7270/weatherforecast").then((result) => {
    result.json().then((result) => {
      console.log(result);
      setWetherForecasts(result as WetherForecasts);
    });
  });

  return wetherForecasts;
};

const fetchDataState = atom({
  key: "FetchData",
  default: [
    {
      Date: new Date(),
      TemperatureC: 0,
      Summary: "",
      TemperatureF: 0,
    },
  ] as WetherForecasts,
});

export default useFetchData;
