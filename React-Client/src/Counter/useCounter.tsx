import { useState } from "react";
import { atom, useRecoilState } from "recoil";
import { UseCounter } from "./Interface";

const useCounter = (): UseCounter => {
  const [count, setCount] = useState(0);
  const [recoilCount, setRecoilCount] = useRecoilState(CountState);

  const increment = () => setCount((pre) => ++pre);
  const recoilIncrement = () => setRecoilCount((pre) => ++pre);

  return { count, increment, recoilCount, recoilIncrement };
};

const CountState = atom({
  key: "CountState",
  default: 0,
});

export default useCounter;
